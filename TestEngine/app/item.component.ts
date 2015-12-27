import {Component} from 'angular2/core'
import {Assessments} from './instrument'

@Component ({
  "selector" : 'item-detail',
  "templateUrl" : '/modules/item.html',
  "inputs" : ['item']
})

export class ItemComponent {

  
  public item : Assessments.Item


}
