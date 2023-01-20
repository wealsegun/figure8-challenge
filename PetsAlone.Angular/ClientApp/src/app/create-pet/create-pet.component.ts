import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { CreatePetModel, PetTypeModel } from "../models/pet.model";
import { PetService } from "../services/pet.service";


@Component({
  selector: 'app-home',
  templateUrl: './create-pet.component.html',
  styleUrls: ['./create-pet.component.scss']
})
export class CreatePetComponent implements OnInit {
  createPetFormGroup!: FormGroup;
  returnUrl: string;
  petTypes!: PetTypeModel[];
  constructor(private fb: FormBuilder, private service: PetService, private router: Router, private route: ActivatedRoute,) {
    this.createPetFormGroup = this.fb.group({
      name: ['', [Validators.required]],
      petType: [0, [Validators.required]],
      missingSince: ['', [Validators.required]],
      missingTime: ['']
    })
  }

  get name() {
    return this.createPetFormGroup.get('name');
  }

  get petType() {
    return this.createPetFormGroup.get('petType');
  }

  get missingSince() {
    return this.createPetFormGroup.get('missingSince');
  }

  get missingTime() {
    return this.createPetFormGroup.get('missingTime');
  }
  ngOnInit() {
    this.getPetType();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

  }

  getPetType() {
    this.service.getPetType().subscribe(response => {
      //console.log(response);
      this.petTypes = response;
    });


  }

  createPet() {
    const date = this.missingSince.value + "T" + this.missingTime.value;
    const pet: CreatePetModel = {
      id: 0,
      name: this.name.value,
      petType: +this.petType.value,
      missingSince: date
    }
    console.log(pet);
    this.service.createPet(pet).subscribe(response => {
      if (response > 0) {
        alert("pet created successful.");
        this.router.navigate([this.returnUrl]).then(() => {
          window.location.reload();
        });
      }
      else {
        alert("pet creation failed");
      }
    }
    )

  }
}
