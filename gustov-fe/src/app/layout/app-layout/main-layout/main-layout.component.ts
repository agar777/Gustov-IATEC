import { Direction, BidiModule } from '@angular/cdk/bidi';
import { AfterViewInit, Component, Inject, PLATFORM_ID, Renderer2 } from '@angular/core';
import { NavigationCancel, NavigationEnd, Router, RouterLink, RouterOutlet } from '@angular/router';
import { SidebarComponent } from '../../../common/sidebar/sidebar.component';
import { FooterComponent } from '../../../common/footer/footer.component';
import { HeaderComponent } from '../../../common/header/header.component';
import { CommonModule, isPlatformBrowser, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { filter } from 'rxjs';
import { ToggleService } from '../../../common/header/toggle.service';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.scss',
  standalone: true,
  imports: [RouterOutlet, CommonModule, RouterLink, SidebarComponent, HeaderComponent, FooterComponent],

  providers: [
    Location, {
        provide: LocationStrategy,
        useClass: PathLocationStrategy
    }
]
})
export class MainLayoutComponent {
  title = 'Trinta -  Angular 17 Material Design Admin Dashboard Template';
  routerSubscription: any;
  location: any;

  constructor(
      public router: Router,
      public toggleService: ToggleService,
      @Inject(PLATFORM_ID) private platformId: Object
  ) {
      this.toggleService.isToggled$.subscribe(isToggled => {
          this.isToggled = isToggled;
      });
  }

  // Toggle Service
  isToggled = false;

  // Dark Mode
  toggleTheme() {
      this.toggleService.toggleTheme();
  }

  // Settings Button Toggle
  toggle() {
      this.toggleService.toggle();
  }

  // ngOnInit
  ngOnInit(){
      if (isPlatformBrowser(this.platformId)) {
          this.recallJsFuntions();
      }
  }

  // recallJsFuntions
  recallJsFuntions() {
      this.routerSubscription = this.router.events
          .pipe(filter(event => event instanceof NavigationEnd || event instanceof NavigationCancel))
          .subscribe(event => {
          this.location = this.router.url;
          if (!(event instanceof NavigationEnd)) {
              return;
          }
          this.scrollToTop();
      });
  }
  scrollToTop() {
      if (isPlatformBrowser(this.platformId)) {
          window.scrollTo(0, 0);
      }
  }

}
