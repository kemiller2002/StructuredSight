import {Component} from 'angular2/core';
import {Assessments} from './instrument';
import {SectionComponent} from './section.component';
import {ItemComponent} from './item.component';
import {Http, Headers} from 'angular2/http';


@Component({
    selector: 'test-author',
    templateUrl: 'modules/author.html',
    directives: [SectionComponent, ItemComponent]
})

export class AppComponent {
  constructor (public http:Http){
    var that = this;

    this.http.get("app/InstrumentExample.js")
    .subscribe(d=>{
      console.log(d.text());
      that.instrument = <Assessments.Instrument>d.json();
    });
  }

  public onSectionSelect(section:Assessments.Section) {
    this.selectedSection = section;
  }

  public selectedSection : Assessments.Section;
  public instrument:Assessments.Instrument;
}
