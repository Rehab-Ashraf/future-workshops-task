import { environment } from "../../../environments/environment";

export const AuthEndPoint = {
   WorkItemGetByID: `${environment.APIUrl}/api/WorkItem/GetByID/{id}`,
   WorkItemSearch:`${environment.APIUrl}/api/WorkItem/Search`,
   WorkItemAdd:`${environment.APIUrl}/api/WorkItem/Add`,
   WorkItemUpdate:`${environment.APIUrl}/api/WorkItem/Update`,
   WorkItemDelete:`${environment.APIUrl}/api/WorkItem/Delete`,
}
