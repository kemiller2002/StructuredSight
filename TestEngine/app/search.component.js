System.register(['angular2/core', 'angular2/http', 'angular2/router', './instrument.component'], function(exports_1) {
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, http_1, router_1, instrument_component_1;
    var SearchComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (instrument_component_1_1) {
                instrument_component_1 = instrument_component_1_1;
            }],
        execute: function() {
            SearchComponent = (function () {
                function SearchComponent(_http, _router) {
                    this._http = _http;
                    this._router = _router;
                    var that = this;
                    this._http.get('app/instrumentExampleList.js')
                        .subscribe(function (d) { return that.instruments = d.json(); });
                }
                SearchComponent.prototype.showDetails = function (instrument) {
                    this._router.navigate(['Instrument', { id: instrument.id.value }]);
                };
                SearchComponent = __decorate([
                    core_1.Component({
                        selector: 'search',
                        templateUrl: 'modules/search.html'
                    }),
                    router_1.RouteConfig([
                        { path: '/instrument/:id', name: 'Instrument', component: instrument_component_1.InstrumentComponent }
                    ]), 
                    __metadata('design:paramtypes', [http_1.Http, router_1.Router])
                ], SearchComponent);
                return SearchComponent;
            })();
            exports_1("SearchComponent", SearchComponent);
        }
    }
});
//# sourceMappingURL=search.component.js.map