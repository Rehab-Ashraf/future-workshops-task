import { Injectable } from "@angular/core";
import { environment } from "../../../environments/environment";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { AuthEndPoint } from "../api/Api.endpoint";
import { Observable } from "rxjs";
import { IWorkItem, IWorkItemsRes, IWorkItemsSearch } from "../models/iWork-item";

@Injectable({
    providedIn: 'root',
  })
  export class WorkItemService{
    baseURL = environment.APIUrl;
    private readonly TOKEN_KEY = 'currentUser';
    constructor(
      private http: HttpClient,
      private router: Router
    ) {
    }

    search(body: IWorkItemsSearch): Observable<IWorkItemsRes> {
        let url: string = `${AuthEndPoint.WorkItemSearch}`;
        return this.http.post<IWorkItemsRes>(url, body);
    }

    delete(id:number){
      let url: string = `${AuthEndPoint.WorkItemDelete}?id=${id}`;
        return this.http.delete(url);
    }

    addWorkItem(body: IWorkItem): Observable<any> {
      let url: string = `${AuthEndPoint.WorkItemAdd}`;
      return this.http.post<any>(url, body);
  }

  editWorkItem(body: IWorkItem): Observable<any> {
    let url: string = `${AuthEndPoint.WorkItemUpdate}`;
    return this.http.put<any>(url, body);
}
}