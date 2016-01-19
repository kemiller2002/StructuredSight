import {Assessments} from './instrument';
import {Http, Headers} from 'angular2/http';
import {Injectable} from 'angular2/core'
//import {Observable} from 'angular2/observable'

@Injectable()

export class InstrumentProxy  {
  constructor (private _http:Http) {
    this.ngOnInit();
  }

  private _instruments : Promise<Assessments.Instrument[]>

  private ngOnInit () {
    this.loadInstruments();
  }
  private loadInstruments () {
    var that = this;
    console.log('loading');

     this._instruments = this._http.get('app/instrumentExampleList.js')
     .map(r=><Assessments.Instrument[]>r.json()).toPromise();
  }

  public getInstruments (id?:string) : Promise<Assessments.Instrument[]> {
    console.log('getting');
    return this._instruments.then(x=>x);
    }
/*
  public getInstruments(id?:string) : Promise<Assessments.Instrument[]>{
    return new Promise<Assessments.Instrument[]>((resolve, reject) => {
    var set = this._instruments.then(
      d=>{
        var set = d.reduce((a,i)=>{
          if (i.id.value === id || !id)
          {
            a.push(i);
          }

          return a;
        }, new Array<Assessments.Instrument>());
        if(set.length > 0){resolve(set)}
        else {reject("no items found")}

      }).catch(error => reject(error));
    } );

  } */

}
