import { Direction, BidiModule } from '@angular/cdk/bidi';
import { Component, Inject, Renderer2 } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { RouterOutlet } from '@angular/router';

@Component({
    selector: 'app-auth-layout',
    templateUrl: './auth-layout.component.html',
    styleUrls: [],
    standalone: true,
    imports: [BidiModule, RouterOutlet],
})
export class AuthLayoutComponent {

}
