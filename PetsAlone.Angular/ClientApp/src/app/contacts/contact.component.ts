import { Component, OnInit } from '@angular/core';
import { ContactModel } from '../models/contact.model';
import { PetModel, PetSearchModel, PetTypeModel } from '../models/pet.model';
import { ContactService } from '../services/contact-details.service';
import { PetService } from '../services/pet.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class ContactComponent implements OnInit {
  contactList: ContactModel[];
  error: string;
  constructor(private service: ContactService) {

  }

  ngOnInit() {
    //const petSearch: PetSearchModel = {
    //  petType: 0
   // }
    //this.getPetList(petSearch);
    //this.getPetType();
  }

  //getPetList(petSearch: PetSearchModel) {
  //  this.service.getPetList(petSearch).subscribe(response => {
  //    this.petList = response;
  //    //console.log(this.petList);
  //  });
  //}

  //getPetTypeDetail(petId: number) {
  //  //console.log(petId);
  //  if (petId != null && petId > 0) {
  //    // ✅ Provide empty array fallback value
  //    const arr = this.petTypes || [];
  //    return arr ? arr.find(c => c.id == petId).name : " ";
  //  }

  //}

  //getPetType() {
  //  this.service.getPetType().subscribe(response => {
  //    //console.log(response);
  //    this.petTypes = response;
  //  });


  //}

  //convertTodate(date: string) {
  //  return new Date(date);
  //}



  //filter(id: number) {
  //  //console.log(id);
  //  const petSearch: PetSearchModel = {
  //    petType: id
  //  }
  //  this.getPetList(petSearch);

  //}

  getContactList() {
    this.service.getAllContact().subscribe(response => {
      console.log(response);
      this.contactList = response;
    })

  }

  deleteContact(id: any) {
    this.service.deleteContact(+id).subscribe(response => {
      console.log(response);
      if (response) {
        this.getContactList();
      }
      else {
        this.error = "Contact deletion failed";
      }
    })
  }

}
