import { ETaskStatus } from "../enum/ETaskStatus";
import { IPagination } from "./IPagination";

export interface IWorkItem{
    id:number,
    name:string,
    dueDate:Date,
    status: ETaskStatus
}
export interface IWorkItemsRes {
    collection: IWorkItem[];
    pagination: IPagination;
    total: number;
  }

  export interface IWorkItemsSearch {
    pagination: {
      pageIndex: number;
      pageSize: number;
      totalCount?: number;
    };
    status?: ETaskStatus;
    name?: string;

  }