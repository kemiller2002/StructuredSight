import {bootstrap}    from 'angular2/platform/browser'
import {AppComponent} from './app.component'
import {Http, Headers, HTTP_BINDINGS} from 'angular2/http'
import {HTTP_PROVIDERS} from 'angular2/http';

bootstrap(AppComponent, [HTTP_PROVIDERS])
