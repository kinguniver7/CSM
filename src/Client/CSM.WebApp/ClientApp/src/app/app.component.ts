import { Component } from '@angular/core';
import { AuthenticationService } from './security/services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';

  constructor(private authenticationService: AuthenticationService) {
  }
}
