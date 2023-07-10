# Josh2DShooter
A simple 2d shooter inspired by the Galaxy Attack video game.

# Why?
I wanted to experiment with neural networks in Unity using ml-agents, but since my most recent experience with ml-agents is more than a year old, I decided to refresh my knowledge. This project is very simple since it doesn't even use multiple agents to make the learning process a lot faster. I just wanted to test if everything still works as it did a year ago. 

# What I had to learn?
The difference between discrete and continuous actions.
The agent (the NN) can return two types of numbers, floats, or integers. If using continuous actions the agent will return floats as fast as possible (gradient ==> continuos). When using discrete actions, the agent is more "focused" on the decision, thus returning integers which mostly mean a decision between yes or no.
