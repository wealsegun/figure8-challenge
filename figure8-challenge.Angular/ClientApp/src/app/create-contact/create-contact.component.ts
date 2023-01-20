import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ContactModel } from "../models/contact.model";
import { ContactService } from "../services/contact-details.service";


@Component({
  selector: 'app-create-contact',
  templateUrl: './create-contact.component.html',
  styleUrls: ['./create-contact.component.css']
})
export class CreateContactComponent implements OnInit {
  createContactFormGroup!: FormGroup;
  error: string;
  returnUrl: string;
  constructor(private fb: FormBuilder, private service: ContactService, private router: Router, private route: ActivatedRoute,) {
    this.createContactFormGroup = this.fb.group({
      name: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required]],
      
    })
  }

  get name() {
    return this.createContactFormGroup.get('name');
  }

  get phoneNumber() {
    return this.createContactFormGroup.get('phoneNumber');
  }

  ngOnInit() {
    
  }

  
  createContact() {

    const _contact: ContactModel = {
      id: 0,
      name: this.name.value,
      phoneNumber: this.phoneNumber.value,
      dateCreated: "2021-03-25",
      updatedAt: null
    };

    console.log(_contact);

    this.service.createContact(_contact).subscribe(response => {
      console.log(response);
      if (response > 0) {
        this.router.navigate(['/contacts']);
      } else {
        this.error = "Contact Creation Failed";
      }
    })



  }
}
