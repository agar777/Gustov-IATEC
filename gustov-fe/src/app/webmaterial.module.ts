import { NgModule } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatStepperModule} from '@angular/material/stepper';
import { MatError, MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {MatTabsModule} from '@angular/material/tabs';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatSelectModule} from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatCheckboxModule } from '@angular/material/checkbox';
import {MatExpansionModule} from '@angular/material/expansion';
import {CdkAccordionModule} from '@angular/cdk/accordion';
import {MatBadgeModule} from '@angular/material/badge';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule } from '@angular/material/dialog';
import { FeathericonsModule } from './icons/feathericons/feathericons.module';
import { ToastModule } from 'primeng/toast';
import {MatMenu, MatMenuModule} from "@angular/material/menu";
@NgModule({
    imports:[
        FeathericonsModule,
        MatToolbarModule,
        MatIconModule,
        MatStepperModule,
        MatFormFieldModule,
        MatInputModule,
        MatTabsModule,
        MatCardModule
    ],
    exports: [
        FeathericonsModule,
        MatToolbarModule,
        MatIconModule,
        MatStepperModule,
        MatFormFieldModule,
        MatInputModule,
        MatTabsModule,
        MatCardModule,
        MatButtonModule,
        MatPaginatorModule,
        MatTableModule,
        MatSlideToggleModule,
        MatSelectModule,
        MatError,
        MatDatepickerModule,
        MatGridListModule,
        MatProgressSpinnerModule,
        MatAutocompleteModule,
        MatCheckboxModule,
        MatExpansionModule,
        CdkAccordionModule,
        MatTooltipModule,
        MatBadgeModule,
        MatDialogModule,
        ToastModule,
        MatMenuModule
    ],
    declarations: [
    ],
})
export class WebMaterialModule { }
