import {Component} from 'angular2/core';
import {Assessments} from './instrument';
import {SectionComponent} from './section.component';
@Component({
    selector: 'test-author',
    templateUrl: 'modules/author.html',
    directives: [SectionComponent]
})

export class AppComponent {
  constructor (){
    this.instrument = new Assessments.Instrument();
    this.instrument.sections.push(new Assessments.Section())
    this.instrument.sections[0].description.text = "NEW NEW NEW"
  }

  public onSectionSelect(section:Assessments.Section) {
    this.selectedSection = section;
  }

  public selectedSection : Assessments.Section;
  public instrument:Assessments.Instrument;
}
