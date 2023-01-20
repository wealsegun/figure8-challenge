import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ContactModel } from "../models/contact.model";
import { ContactService } from "../services/contact-details.service";


@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent implements OnInit {
  id: number;
  editContactFormGroup!: FormGroup;
  error: string;
  contact: ContactModel;
  returnUrl: string;
  constructor(private fb: FormBuilder, private service: ContactService, private router: Router, private activateRoute: ActivatedRoute) {
    this.editContactFormGroup = this.fb.group({
      name: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required]],

    })
  }

  get name() {
    return this.editContactFormGroup.get('name');
  }

  get phoneNumber() {
    return this.editContactFormGroup.get('phoneNumber');
  }

  ngOnInit() {
    this.id = this.activateRoute.snapshot.params['id'];
    console.log(this.id);
    this.getContactDetails(this.id);
  }

  getContactDetails(id: number) {
    this.service.getContactById(id).subscribe(response => {
      console.log(response);
      this.contact = response;
      this.editContactFormGroup.patchValue({
        name: response.name,
        phoneNumber: response.phoneNumber
      });

    })
  }

  //this.editBranchForm.patchValue({
  //  name: this.theBranch.name,
  //  street: this.theBranch.street,
  //  branchCode: this.theBranch.branchCode,
  //  countryId: this.theBranch.countryId,
  //  countryStateId: this.theBranch.countryStateId,
  //});

  updateContact() {
    const _edit: ContactModel = {
      id: this.contact.id,
      name: this.editContactFormGroup.value.name,
      phoneNumber: this.editContactFormGroup.value.phoneNumber,
      dateCreated: this.contact.dateCreated,
      updatedAt: null
    }

    this.service.updateContact(_edit, this.id).subscribe(response => {
      console.log(response);
      if (response) {
        this.router.navigate(['/contacts']);
      }
    })
  }
  //createContact() {

  //  const _contact: ContactModel = {
  //    id: 0,
  //    name: this.name.value,
  //    phoneNumber: this.phoneNumber.value,
  //    dateCreated: "2021-03-25",
  //    updatedAt: null
  //  };

  //  console.log(_contact);

  //  this.service.createContact(_contact).subscribe(response => {
  //    console.log(response);
  //    if (response > 0) {
  //      this.router.navigate(['/contacts']);
  //    } else {
  //      this.error = "Contact Creation Failed";
  //    }
  //  })



  //}
}
