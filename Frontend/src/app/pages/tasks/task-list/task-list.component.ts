import { CommonModule, DatePipe } from '@angular/common';
import { Component, inject, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BehaviorSubject, combineLatest, debounceTime, distinctUntilChanged, switchMap } from 'rxjs';
import { ETaskStatus } from '../../../core/enum/ETaskStatus';
import { WorkItemService } from '../../../core/services/WorkItemService';
import { IWorkItem } from '../../../core/models/iWork-item';
import { IPagination } from '../../../core/models/IPagination';
import { DeleteComponent } from '../../../components/delete/delete.component';
import { MatDialog } from '@angular/material/dialog';
import { TaskAddEditComponent } from '../task-add-edit/task-add-edit.component';

@Component({
  selector: 'app-task-list',
  imports: [
    FormsModule,
    CommonModule,
    DatePipe
  ],
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.scss'
})
export class TaskListComponent {
  readonly workItemService = inject(WorkItemService);
  searchQuery = '';
  searchSubject = new BehaviorSubject<string>('');
  selectedStatusSubject = new BehaviorSubject<ETaskStatus | null>(null);
  readonly status = ETaskStatus;

  workItems!: IWorkItem[];
  selectedWorkItem!: IWorkItem;
  selectedWorkItemId!: number;
  pagination: IPagination = {
    pageIndex: 0,
    pageSize: 5,
    totalCount: 0,
  };
  constructor(private dialog: MatDialog) {
    this.loadTaskes();
    this.searchSubject.next('');
  }

  onSearchModelChange(ev: string) {
    this.searchSubject.next(ev);
  }

  loadTaskes() {
    combineLatest([
      this.selectedStatusSubject.pipe(distinctUntilChanged()),
      this.searchSubject.pipe(debounceTime(1000), distinctUntilChanged()),
    ])
      .pipe(
        switchMap((searchQuery) =>
          this.workItemService.search({
            pagination: {
              pageIndex: this.pagination.pageIndex,
              pageSize: this.pagination.pageSize,
            },
            //status: this.selectedStatusSubject.value,
            name: this.searchSubject.value,
          })
        )
      )
      .subscribe({
        next: (data) => {
          this.workItems = data.collection;
          this.pagination.totalCount = data.pagination.totalCount;
        },
      });
  }
  onActiveItemChange(event: any) {
    this.selectedStatusSubject.next(event.id);
  }
  get totalPages(): number[] {
    const totalPages = Math.ceil(this.pagination.totalCount / this.pagination.pageSize);
    return Array(totalPages).fill(0).map((_, i) => i + 1); // [1, 2, 3, ...]
  }
  pageChange(page: number) {
    this.pagination = {
      ...this.pagination,
      pageIndex: page,
      pageSize: 5,
    };

    this.loadTaskes();
  }
  getStatusTag(status: ETaskStatus): { label: string; class: string } {
    switch (status) {
      case ETaskStatus.NotStarted:
        return { label: 'Not Started', class: 'bg-secondary text-white' };
      case ETaskStatus.InProgress:
        return { label: 'In Progress', class: 'bg-warning text-dark' };
      case ETaskStatus.Completed:
        return { label: 'Completed', class: 'bg-success text-white' };
      default:
        return { label: 'Unknown', class: 'bg-dark text-white' };
    }
  }

  onDelete(item:IWorkItem){
    const dialogRef = this.dialog.open(DeleteComponent, {
      width: '500px',
      maxWidth: '90vw',
      data: { taskName: item.name },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result)
      if (result == true) {
        this.deleteTask(item);
      }
    });
  }

  deleteTask(item:IWorkItem){
    this.workItemService.delete(item.id).subscribe((res)=>{
      this.loadTaskes();
    })
  }

  createTask() {
    const dialogRef = this.dialog.open(TaskAddEditComponent, {
      width: '500px',
      maxWidth: '90vw',
      data: null,
    });
  
    dialogRef.afterClosed().subscribe((result: IWorkItem) => {
      if (result) {
        console.log('Create new task:', result);
        this.workItemService.addWorkItem(result).subscribe((res)=>{
          this.loadTaskes();
        })
      }
    });
  }
  
  editTask(task: IWorkItem) {
    const dialogRef = this.dialog.open(TaskAddEditComponent, {
      width: '400px',
      data: task,
    });
  
    dialogRef.afterClosed().subscribe((result: IWorkItem) => {
      if (result) {
        console.log('Updated task:', result);
        this.workItemService.editWorkItem(result).subscribe((res)=>{
          this.loadTaskes();
        })
      }
    });
  }
}
