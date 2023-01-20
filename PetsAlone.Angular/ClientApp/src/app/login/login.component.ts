import { Component, Inject,OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { CurrentService } from '../services/currentUser.service';

@Component({
  templateUrl: './login.component.html'
})

export class LoginComponent implements OnInit {
  model: any = {};
  loading = false;
  returnUrl: string;
  showInvalidUserMessage=false;

  constructor(
    private http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    private route: ActivatedRoute,
    private currentServicer: CurrentService,
    private router: Router) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  login() {
    this.loading = true;
    this.http.post('/api/users/login',
      JSON.stringify({ username:this.model.username, password: this.model.password }),
      {
        headers:new HttpHeaders()
          .set('Content-Type','application/json')
      }
      )
      .subscribe(result => {
        if (result && result) {
          this.currentServicer.addToken(result['token']);
          this.currentServicer.addUserProfile(result['profile']);
          this.router.navigate([this.returnUrl]).then(() => {
            window.location.reload();
          });
          
        }
      }, error => {
        this.showInvalidUserMessage = true;
        this.router.navigate([this.returnUrl + "/login"]);
       
      });
  }

  refresh(): void {
    window.location.reload();
  }

  
}
