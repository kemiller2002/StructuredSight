import {Component} from 'angular2/core';
import {Assessments} from './instrument';
import {SectionComponent} from './section.component';
import {Http, Headers} from 'angular2/http';
import {ROUTER_PROVIDERS, RouteConfig} from 'angular2/router'
import {ItemComponent} from './item.component';

@Component({
    selector: 'search',
    templateUrl: 'modules/search.html'
})


export class SearchComponent {
    constructor (private http:Http) {
        var that = this;

        this.http.get('app/instrumentExampleList.js')
        .subscribe(d=>that.instruments = <Assessments.Instrument[]>d.json());
    }

    public instruments : Assessments.Instrument[]


}
