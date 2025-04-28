
class Bar:
    maxVal = 0
    numBars = 0
    displayWidth = 120

    def __init__(self, value, desc):
        if value < 0:
            raise ValueError

        if value > Bar.maxVal:
            Bar.maxVal = value

        self.Barval = value
        self.BarDesc = desc

    @classmethod
    def get_width(cls, value):
        percentage = value / cls.maxVal
        return percentage * cls.displayWidth


    def draw(self, character="*"):
        width = self.get_width(self.Barval)
        string = ""
        print(Bar.displayWidth)
        print(width)
        for x in range(int(width)):
            string += character
        print(string)

    def __str__(self):
        return f"Bar : {self.BarDesc} = {self.Barval}"

    def __repr__(self):
        return f"Bar: Num Bars = {Bar.numBars}, Max Value = {Bar.maxVal}, Value = {self.Barval}, Calculated  Width = {self.Barval} / {Bar.displayWidth}"



class ColorBar(Bar):
    def __init__(self, value, desc, forecolor):

        super().__init__(value, desc)
        self._forecolor = forecolor

    def draw(self, character="*"):
        print("Not yet implemented")

    def __str__(self):
        return "ColourBar: " + super().__str__()

    def __repr__(self):
        return  "ColourBar: " + super().__repr__()

class ValueBar(Bar):

    def __init__(self, value, desc, forecolor, backcolor):
        super().__init__(value, desc)

        self._forecolor = forecolor
        self._backcolor = backcolor

    def draw(self, character="*"):
        super().draw(character)

    def __str__(self):
        return "ValueBar: " + super().__str__()

    def __repr__(self):
        return  "ValueBar: " + super().__repr__()