import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CurrentService } from '../services/currentUser.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  model: any = {};
  token: string;
  loading = false;
  returnUrl: string;
  showInvalidUserMessage = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    private route: ActivatedRoute,
    private currentServicer: CurrentService,
    private router: Router) {
    this.getToken();
    this.getProfile();

  }

  ngOnInit() {
    this.getToken();
    this.getProfile();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
  ngOnChnages() {

  }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  getProfile() {
    this.model = this.currentServicer.getUserProfile();
    //console.log(this.model);
  }
  getToken() {
    this.token = this.currentServicer.getToken();
    //console.log(this.token);
    
  }


  logout() {
    this.currentServicer.logout();
    this.router.navigate([this.returnUrl]).then(() => {
      window.location.reload();
    });
    ////this.router.navigate([this.returnUrl + "/login"]);
    
  }

  reload() {
    window.location.reload();
  }
}
