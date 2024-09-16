import { Employee } from "./employee.model";

export class Requests {
   id: number;
   employeeId: number;
   requestDate: string;
   status: string;
   employee:Employee
}