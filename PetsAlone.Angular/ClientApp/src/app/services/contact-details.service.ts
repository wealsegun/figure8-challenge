import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment";
import { ContactModel } from "../models/contact.model";
//import { LoginModel } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  base!: string;
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base = baseUrl;
  }

  getAllContact(): Observable<any> {
    const url = `${environment.baseUrl}api/ContactDetails/get-all-contact`;
    return this.httpClient.get<any>(url);
  }

  getAllContactByUserId(userId: number): Observable<any> {
    const url = `${this.base}api/contact/get-all-contact/${userId}`;
    return this.httpClient.get<any>(url);
  }

  getContactById(id: number): Observable<any> {
    const url = `${this.base}api/contact/get-contact/${id}`;
    return this.httpClient.get<any>(url);
  }

  createContact(model: ContactModel): Observable<any> {
    const url = `${this.base}api/contact/create`;
    return this.httpClient.post<any>(url, model);
  }

  updateContact(model: ContactModel): Observable<any> {
    const url = `${this.base}api/contact/update`;
    return this.httpClient.put<any>(url, model);
  }

  deleteContact(id: number): Observable<any> {
    const url = `${this.base}api/contact/delete/${id}`;
    return this.httpClient.delete<any>(url);
  }
}
