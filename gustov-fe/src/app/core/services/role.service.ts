import { HttpClient } from "@angular/common/http";
import { Role } from "../models/role.model";
import { Injectable } from "@angular/core";
import { ApiBase } from "../base-api/api-base";

@Injectable({
    providedIn: 'root'
})

export class RoleService extends ApiBase<Role> {
    
    constructor(httpClient: HttpClient) {
        super(httpClient);
        this.baseUrl = '/Role'
    }
}