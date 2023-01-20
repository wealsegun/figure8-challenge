import { Component, OnInit } from '@angular/core';
import { ContactModel } from '../models/contact.model';
import { ContactService } from '../services/contact-details.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  contactList: ContactModel[];
  error: string;
  constructor(private service: ContactService) {

  }

  ngOnInit() {
    this.getContactList();
  }


  getContactList() {
    this.service.getAllContact().subscribe(response => {
      console.log(response);
      this.contactList = response;
    })

  }

  deleteContact(id: any) {
    console.log(id);
    this.service.deleteContact(+id).subscribe(response => {
      console.log(response);
      if (response) {
        this.getContactList();
      } else {
        alert("Contact Deteion failed!!");
      }
    })
  }

}
