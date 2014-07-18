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
     rangeRoundBands(upperAndLowerBound: number[], rounding: number);
}

 interface IScale {
     scale: IScale;
     linear(): IBounds;
     ordinal(): IBounds;
     (IBounds) : IScale;
 }

interface  IData {
    enter(): IHtml;
}

interface IGraphFunctions extends  IRender {
    x(f: (d: number, i: number) => number): IGraphFunctions ;
    y(f: (d: number, i: number) => number): IGraphFunctions ;
}

interface IAxis {
    scale(dimension: any): IAxis;
    orient(orientation:string) : IAxis;
}

interface IGraphType {
    line(): IGraphFunctions;
    axis() : IAxis;
}

interface  IHtml {
    append(htmlNode: string): IGraphingUtility;
    attr(attribute: string, value: string): IGraphingUtility;
    attr(attribute: string, value: IBounds);
    attr(attribute: string, applicant: (datum: number) => number);
    attr(attribute:string, value:number);
}

interface IGraphingUtility extends IScale, IHtml {
    select(id: string): IGraphingUtility;
    selectAll(id:string) : IHtmlCollection;
    svg: IGraphType;
    max(data: number[]): number;
    max(data: IKvp[]): number;
    max(data:IKvp[], transform : (kvp:IKvp) => number);
}

interface IHtmlCollection {
    data(d: any[]) :IHtmlCollection;
    enter(): IHtmlCollection;
    append(node: string): IHtmlCollection;
    attr(attribute:string, transformation : (datum: number, index:number) => string) : IHtml;
}

interface IKvp {
    name: string;
    value:number;
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

function openBarGraphUtility(d3: IGraphingUtility): (htmlWrapperName: string, data: IKvp[], height:number, width:number) => void {

    return (wrapper: string, data: IKvp[], pHeight: number, pWwidth: number) => {

        var margin = { top: 20, right: 30, bottom: 30, left: 40 },
            width = 960 - margin.left - margin.right,
            height = 500 - margin.top - margin.bottom;

        var x = d3.scale.ordinal()
            .rangeRoundBands([0, width], .1)
            .domain(data.map((d) => { return d.name; }));

        var y = d3.scale.linear()
            .range([height, 0])
            .domain([0, d3.max(data, (d) => { return d.value; })]);

        var xAxis = d3.svg.axis()
            .scale(x)
            .orient("bottom");

        var yAxis = d3.svg.axis()
            .scale(y)
            .orient("left");

        var chart = d3.select(".chart")
            .attr("width", width + margin.left + margin.right)
            .attr("height", height + margin.top + margin.bottom)
            .append("g")
            .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

        chart.append("g")
            .attr("class", "x axis")
            .attr("transform", "translate(0," + height + ")")
            .call(xAxis);

        chart.append("g")
            .attr("class", "y axis")
            .call(yAxis);

        chart.selectAll(".bar")
            .data(data)
            .enter().append("rect")
            .attr("class", "bar")
            .attr("x", (d) => { return x(d.name); })
            .attr("y", (d) => { return y(d.value); })
            .attr("height", (d) => { return height - y(d.value); })
            .attr("width", x.rangeBand());


    };


}
