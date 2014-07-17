var d3: any;


interface ICalculate {
     (number): number;
 }

 interface IRender {
     (number) : string;
 }

 interface IBounds extends ICalculate {
    domain(upperAndLowerBound: number[]): IBounds;
    range(upperAndLowerBound: number[]): IBounds;
}

 interface IScale {
     scale: IScale;
    linear(): IBounds;
 }

interface  IData {
    enter(): IHtml;
}

interface IGraphFunctions extends  IRender {
    x(f: (d: number, i: number) => number): IGraphFunctions ;
    y(f: (d: number, i: number) => number): IGraphFunctions ;
}

interface IGraphType {
    line (): IGraphFunctions;
}

interface  IHtml {
    append(htmlNode: string): IGraphingUtility;
    attr(attribute: string, value: string): IGraphingUtility;
}

interface IGraphingUtility extends IScale, IHtml {
    select(id: string): IGraphingUtility;
    selectAll(id:string) : IHtmlCollection;
    svg: IGraphType;
    max(data : number[]): number;
}

interface IHtmlCollection {
    data(d: any[]) :IHtmlCollection;
    enter(): IHtmlCollection;
    append(node: string): IHtmlCollection;
    attr(attribute:string, value:string) : IHtmlCollection;
}

function openSparkGraphUtility(grapher: IGraphingUtility) : (string) => void {

    return (wrapper: string) => {
        var g = grapher.select("#" + wrapper).append("svg:svg").attr("width", "100%").attr("height", "100%");
        var x = grapher.scale.linear().domain([0, 50]).range([0, 100]);
        var y = grapher.scale.linear().domain([0, 50]).range([0, 100]);

        var svg = d3.svg.line().x((d, i) => { return x(i); }).y((d, i) => { return y(d); });
      
        return (data: number[]) => { g.append("svg:path").attr("d", svg(data)); };
    };
}

function openBarGraphUtility(grapher: IGraphingUtility): (string, number) => void {

    return (wrapper: string, data:number[]) => {
        var g = grapher.select("#" + wrapper).append("svg:svg").attr("width", "100%").attr("height", "100%");

        g.selectAll("g").
        
        var x = grapher.scale.linear().domain([0, grapher.max(data)]).range([0, 100]);
        //var y = grapher.scale.linear().domain([0, 50]).range([0, 100]);

        var svg = d3.svg.line().x((d, i) => { return x(i); }).y((d, i) => { return y(d); });
    };
}
