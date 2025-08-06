import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./pages/tasks/task-list/task-list.component').then(
        (mod) => mod.TaskListComponent
      ),
    title: 'Task Overview | Productivity App',
    },
    {
        path: 'Tasks',
        loadChildren: () =>
            import('./pages/tasks/tasks-routes').then(
              (mod) => mod.Tasks_ROUTES
            ),
    },


];
