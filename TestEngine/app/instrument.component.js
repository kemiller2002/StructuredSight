System.register(['angular2/core', './section.component', 'angular2/http'], function(exports_1) {
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, section_component_1, http_1;
    var InstrumentComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (section_component_1_1) {
                section_component_1 = section_component_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            }],
        execute: function() {
            InstrumentComponent = (function () {
                function InstrumentComponent(http) {
                    this.http = http;
                    var that = this;
                    this.http.get("app/InstrumentExample.js")
                        .subscribe(function (d) {
                        that.instrument = d.json();
                    });
                }
                InstrumentComponent.prototype.onSectionSelect = function (section) {
                    this.selectedSection = section;
                };
                InstrumentComponent = __decorate([
                    core_1.Component({
                        selector: 'test-author',
                        templateUrl: 'modules/author.html',
                        directives: [section_component_1.SectionComponent]
                    }), 
                    __metadata('design:paramtypes', [http_1.Http])
                ], InstrumentComponent);
                return InstrumentComponent;
            })();
            exports_1("InstrumentComponent", InstrumentComponent);
        }
    }
});
//# sourceMappingURL=instrument.component.js.map