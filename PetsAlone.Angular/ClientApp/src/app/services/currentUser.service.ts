import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { UserModel } from "../models/user.model";

@Injectable({
  providedIn: 'root'
})
export class CurrentService {
  constructor() {

  }

  getUserProfile(): UserModel {
    return JSON.parse(localStorage.getItem('profile')) as UserModel;
  }

  addUserProfile(profile: any) {
    localStorage.setItem('profile', JSON.stringify(profile));
  }

  addToken( token: any) {
    localStorage.setItem('token', JSON.stringify(token));
  }

  getToken() {
    return localStorage.getItem('token');
  }

  logout() {
    localStorage.removeItem('profile');
    localStorage.removeItem('token');
  }
}
