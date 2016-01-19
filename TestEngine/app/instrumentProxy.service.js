System.register(['angular2/http', 'angular2/core'], function(exports_1) {
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var http_1, core_1;
    var InstrumentProxy;
    return {
        setters:[
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            //import {Observable} from 'angular2/observable'
            InstrumentProxy = (function () {
                function InstrumentProxy(_http) {
                    this._http = _http;
                    this.ngOnInit();
                }
                InstrumentProxy.prototype.ngOnInit = function () {
                    this.loadInstruments();
                };
                InstrumentProxy.prototype.loadInstruments = function () {
                    var that = this;
                    console.log('loading');
                    this._instruments = this._http.get('app/instrumentExampleList.js')
                        .map(function (r) { return r.json(); }).toPromise();
                };
                InstrumentProxy.prototype.getInstruments = function (id) {
                    console.log('getting');
                    return this._instruments.then(function (x) { return x; });
                };
                InstrumentProxy = __decorate([
                    core_1.Injectable(), 
                    __metadata('design:paramtypes', [http_1.Http])
                ], InstrumentProxy);
                return InstrumentProxy;
            })();
            exports_1("InstrumentProxy", InstrumentProxy);
        }
    }
});
//# sourceMappingURL=instrumentProxy.service.js.map