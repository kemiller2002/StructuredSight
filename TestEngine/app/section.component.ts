import {Component} from 'angular2/core'
import {Assessments} from './instrument';

@Component({
    selector: 'section-detail',
    templateUrl: 'modules/section.html',
    inputs:['section']
  }
)

export class SectionComponent {
  public section:Assessments.Section

  public addItem(section:Assessments.Section){
    section.items.push(new Assessments.Item());
  }

  public removeItem(section:Assessments.Section, item:Assessments.Item){

  }

  public addDistractor(item:Assessments.Item){
    item.distractors.push(new Assessments.Distractor());
  }
}
