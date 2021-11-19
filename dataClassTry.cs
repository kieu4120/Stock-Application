using System;
using System.Collections.Generic;

namespace COP4365Project3
{

    public partial class JsonClass
    {
        public Chart Chart { get; set; }
    }

    public partial class Chart
    {
        public List<Result> Result { get; set; }
        public object Error { get; set; }
    }

    public partial class Result
    {
        public Meta Meta { get; set; }
        public List<long> Timestamp { get; set; }
        public Indicators Indicators { get; set; }
    }

    public partial class Indicators
    {
        public List<Quote> Quote { get; set; }
        public List<Adjclose> Adjclose { get; set; }
    }

    public partial class Adjclose
    {
        public List<double> AdjcloseAdjclose { get; set; }
    }

    public partial class Quote
    {
        public List<double> High { get; set; }
        public List<double> Close { get; set; }
        public List<double> Open { get; set; }
        public List<long> Volume { get; set; }
        public List<double> Low { get; set; }
    }

    public partial class Meta
    {
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string ExchangeName { get; set; }
        public string InstrumentType { get; set; }
        public long FirstTradeDate { get; set; }
        public long RegularMarketTime { get; set; }
        public long Gmtoffset { get; set; }
        public string Timezone { get; set; }
        public string ExchangeTimezoneName { get; set; }
        public double RegularMarketPrice { get; set; }
        public double ChartPreviousClose { get; set; }
        public long PriceHint { get; set; }
        public CurrentTradingPeriod CurrentTradingPeriod { get; set; }
        public string DataGranularity { get; set; }
        public string Range { get; set; }
        public List<string> ValidRanges { get; set; }
    }

    public partial class CurrentTradingPeriod
    {
        public Post Pre { get; set; }
        public Post Regular { get; set; }
        public Post Post { get; set; }
    }

    public partial class Post
    {
        public string Timezone { get; set; }
        public long Start { get; set; }
        public long End { get; set; }
        public long Gmtoffset { get; set; }
    }
}

