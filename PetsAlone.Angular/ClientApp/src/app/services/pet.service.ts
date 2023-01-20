import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment";
import { CreatePetModel, PetSearchModel, PetTypeModel } from "../models/pet.model";

@Injectable({
  providedIn: 'root'
})
export class PetService {
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {

  }

  getPetList(petSearch: PetSearchModel): Observable<any> {
    const url = environment.baseUrl + `/api/pets/getpets/${petSearch.petType}`;
    return this.httpClient.get<any>(url);

  }

  getPet(petId: number): Observable<any> {
    const url = environment.baseUrl + `${petId}`;
    return this.httpClient.get<any>(url);
  }

  createPet(pet: CreatePetModel): Observable<any> {
    const url = environment.baseUrl + `/api/pets/create`;
    return this.httpClient.post<any>(url, pet);
  }

  getPetType() {
    return this.httpClient.get<PetTypeModel[]>("../../assets/petType.json");
  }

}
