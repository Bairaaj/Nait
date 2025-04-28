import threading

import clr

import pythonnet

import random

clr.AddReference('GDIDrawer')

from GDIDrawer import CDrawer
from GDIDrawer import RandColor


from System.Drawing import Color


def GDITester():
    canvas = CDrawer()
    canvas.ContinuousUpdate = False
    for x in range(10):
        col = RandColor.GetColor()
        radius = random.randint(20,200)
        canvas.AddCenteredEllipse(
            random.randint(radius,canvas.ScaledWidth - radius),
            random.randint(radius,canvas.ScaledHeight - radius),
            radius * 2, radius * 2, col )
        canvas.Render()

def canvasKeyboardCallback( IsDown, keyCode, can ):
    print( f"IsDown:{IsDown}, keyCode{keyCode}" )

# Now to wire up the event, perhaps unsurprisingly, pythonnet.clr provides standard event wiring.
# After adding the above function,
# Add the following line to your GDITester()

canvas.KeyboardEvent += canvasKeyboardCallback


GDITester()

class Shape:

    def __init__(self, width, height, CDrawer):
        self.center = random.randint(CDrawer.width - width, CDrawer.height - height)
        self.id = threading.get_native_id()

    @classmethod
    def Draw(self, CDrawer):
        pass

    @classmethod
    def DrawShape(self, CDrawer):
        self.Draw(CDrawer)

class Block(Shape):

    def __init__(self, width, height, CDrawer, Color):
        super.__init__(width, height, CDrawer)
        self._color = Color

    def Draw(self, CDrawer):
        CDrawer.AddCenteredEllipse(self.wi)