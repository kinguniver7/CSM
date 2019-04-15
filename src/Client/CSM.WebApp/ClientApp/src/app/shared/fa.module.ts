import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faCoffee, faIgloo, faAddressCard, faComments, faBars, faTimesCircle } from '@fortawesome/free-solid-svg-icons';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FontAwesomeModule
  ],
  exports: [
    FontAwesomeModule
  ]
})
export class FaModule {
  constructor() {
    // Add an icon to the library for convenient access in other components
    library.add(faCoffee, faIgloo, faAddressCard, faComments, faBars, faTimesCircle);
  }}
