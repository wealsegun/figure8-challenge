import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { PetService } from './services/pet.service';
import { CurrentService } from './services/currentUser.service';
import { CreatePetComponent } from './create-pet/create-pet.component';
import { CommonModule } from '@angular/common';
import { ContactComponent } from './contacts/contact.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    CreatePetComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'create-pet', component: CreatePetComponent },
      { path: 'contacts', component: ContactComponent }
    ])
  ],
  providers: [PetService, CurrentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
