export interface PetModel {
  id: number;
  name: string;
  petType: number;
  missingSince: string;
}

export interface PetSearchModel {
  petType: number;
}

export interface CreatePetModel {
  id: number;
  name: string;
  petType: number;
  missingSince: string;
}

export interface PetTypeModel {
  id: number;
  name: string;
  emoji: string;
}
