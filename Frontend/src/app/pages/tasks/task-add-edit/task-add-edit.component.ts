import { Component, Inject } from '@angular/core';
import { ETaskStatus } from '../../../core/enum/ETaskStatus';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { IWorkItem } from '../../../core/models/iWork-item';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { formatDate, NgForOf } from '@angular/common';
@Component({
  selector: 'app-task-add-edit',
  imports: [    
    MatDialogModule,
    MatButtonModule,
    MatIconModule,
    ReactiveFormsModule,
    MatInputModule,
    MatSelectModule,
    MatOptionModule,
    NgForOf
  ],
  templateUrl: './task-add-edit.component.html',
  styleUrl: './task-add-edit.component.scss'
})
export class TaskAddEditComponent {
  workItemForm: FormGroup;
  statusOptions = [
    { value: ETaskStatus.NotStarted, label: 'Not Started' },
    { value: ETaskStatus.InProgress, label: 'In Progress' },
    { value: ETaskStatus.Completed, label: 'Completed' },
  ];

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<TaskAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IWorkItem | null
  ) {
    console.log('dataaaaaaa',data)
    this.workItemForm = this.fb.group({
      id:[data?.id ?? 0],
      name: [data?.name || '', Validators.required],
      dueDate: [data?.dueDate ? formatDate(data.dueDate, 'yyyy-MM-dd', 'en') : '', Validators.required],
      status: [data?.status || ETaskStatus.NotStarted, Validators.required],
    });
  }

  save() {
    if (this.workItemForm.valid) {
      this.dialogRef.close({
        ...this.data,
        ...this.workItemForm.value,
      });
    }
  }

  cancel() {
    this.dialogRef.close();
  }
}
