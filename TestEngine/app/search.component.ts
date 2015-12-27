import {Component} from 'angular2/core';
import {Assessments} from './instrument';
import {SectionComponent} from './section.component';
import {Http, Headers} from 'angular2/http';
import {ROUTER_PROVIDERS, RouteConfig, Router} from 'angular2/router'
import {ItemComponent} from './item.component';
import {InstrumentComponent} from './instrument.component';

@Component({
    selector: 'search',
    templateUrl: 'modules/search.html'
})

@RouteConfig([
  {path:'/instrument/:id', name:'Instrument', component:InstrumentComponent}
])

export class SearchComponent {
    constructor (private _http:Http, private _router: Router) {
        var that = this;

        this._http.get('app/instrumentExampleList.js')
        .subscribe(d=>that.instruments = <Assessments.Instrument[]>d.json());
    }

    public showDetails(instrument:Assessments.Instrument) {
      this._router.navigate(['Instrument', {id:instrument.id.value}])
    }

    public instruments : Assessments.Instrument[]


}
