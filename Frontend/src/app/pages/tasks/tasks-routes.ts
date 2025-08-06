import { Route } from "@angular/router";
import { TaskListComponent } from "./task-list/task-list.component";

export const Tasks_ROUTES: Route[] = [
    {
        path: 'Tasks',
        component: TaskListComponent,
        data: { title: 'Tasks - List' },
      },
]