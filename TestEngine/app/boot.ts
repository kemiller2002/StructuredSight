import {bootstrap}    from 'angular2/platform/browser'
import {SearchComponent} from './search.component'
import {Http, Headers, HTTP_BINDINGS} from 'angular2/http'
import {HTTP_PROVIDERS} from 'angular2/http';
import {ROUTER_PROVIDERS} from 'angular2/router';

bootstrap(SearchComponent, [HTTP_PROVIDERS, ROUTER_PROVIDERS])
