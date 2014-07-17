interface ICalculate {
    (number): number; 
}
interface IBounds {
    domain(upperAndLowerBound: number[]): IBounds;
    range(upperAndLowerBound: number[]): IBounds;
    ICalculate;
}

interface IScale {
    linear(): IBounds;
}

interface IGraphFunctions {
    x(f: (d: number, i: number) => number): IGraphFunctions ;
    y(f: (d: number, i: number) => number): IGraphFunctions ;
}

interface IGraphType {
    line (): IGraphFunctions;
}

interface IGraphingUtility extends IScale {
    select(id: string): IGraphingUtility;
    append(htmlNode: string): IGraphingUtility;
    attr(attribute: string, value: string): IGraphingUtility;
    svg: IGraphType;
}

function openGraphUtility(grapher: IGraphingUtility) {

    function getGraph(wrapper: string) {
        var g = grapher.select(wrapper).append("svg:svg").append("width:100%").append("width:100%");
        var x = g.linear().domain([0, 50]).range([0, 50]);
        var y = g.linear().domain([0, 50]).range([0, 50]);

        var svg = grapher.svg.line().x((d, i) => { return x(d); }).y((d, i) => return y(i););

    }
}

