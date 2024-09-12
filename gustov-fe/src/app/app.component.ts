declare let $: any;
import { filter } from 'rxjs/operators';
import { isPlatformBrowser } from '@angular/common';
import { Component, Inject, PLATFORM_ID } from '@angular/core';
import { HeaderComponent } from './common/header/header.component';
import { FooterComponent } from './common/footer/footer.component';
import { ToggleService } from '../app/common/header/toggle.service';
import { SidebarComponent } from './common/sidebar/sidebar.component';
import { CommonModule, Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { RouterOutlet, Router, NavigationCancel, NavigationEnd, RouterLink } from '@angular/router';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [RouterOutlet, CommonModule, RouterLink, SidebarComponent, HeaderComponent, FooterComponent],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    providers: [
        Location, {
            provide: LocationStrategy,
            useClass: PathLocationStrategy
        }
    ]
})
export class AppComponent {



}