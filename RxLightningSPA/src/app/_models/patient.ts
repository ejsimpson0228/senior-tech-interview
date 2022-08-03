

export class Patient {
    uiId: number;
    firstName: string;
    lastName: string;
    gender: string;
    dateOfBirth: string;
    addressLine1: string;
    addressLine2: string;
    city: string;
    state: string;
    postalCode: string;

    constructor(uiId: number,
        firstName: string,
        lastName: string,
        gender: string,
        dateOfBirth: string,
        addressLine1: string,
        addressLine2: string,
        city: string,
        state: string,
        postalCode: string) {
        this.uiId = uiId;
        this.firstName = firstName;
        this.lastName = lastName;
        this.gender = gender;
        this.dateOfBirth = dateOfBirth;
        this.addressLine1 = addressLine1;
        this.addressLine2 = addressLine2
        this.city = city;
        this.state = state;
        this.postalCode = postalCode;
    }
}