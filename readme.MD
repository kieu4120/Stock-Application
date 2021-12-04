an  interval: the y axis is divided into 5 equals interval based on the min and max value of the chart

Since the chart is responsive to the data,Doji patterns are recognized using the scale and threshold computed from an interval of the chart.

The code is set with the default values(scale argument in the functions) to create the threshold to recognize the patterns

- neutral
    
    when the absolute value of the subtraction of open and close are within 5% of the interval
    
- long legged
    
    when the candlestick is doji and the absolute value of (subtraction of high and open, low and close) is greater than 70% of the interval
    
- dragon fly
    
    when the candle stick is doji and the difference of high values vs open, close value is less than or equal to 6.5%
    
- gravestone
    
    when the absolute value of the subtraction of which 2 values is the lowest, less than or equal to 3% of an interval
    
- bullish(green)
    
    When close > open and the difference of close vs high and open vs low is less than 1.4%
    
- bearish(red)
    
    when open > close and the difference of close vs low and high vs open is less than 1.4%
