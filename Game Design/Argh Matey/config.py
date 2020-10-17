#config.py
import time
import random
import threading

name = ""
drinks = 0
health = 100
oppHealth = 100
strength = 5
oppStrength = 5
oppQuickness = 8
hat = False
sword = False
inventory = []
save = []
tutorial = True
fightLock = threading.Lock()
response = ""
bearSlain = False