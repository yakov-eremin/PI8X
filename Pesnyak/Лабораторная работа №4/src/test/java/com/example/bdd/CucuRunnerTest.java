package com.example.bdd;

import cucumber.api.CucumberOptions;
import cucumber.api.junit.*;
import org.junit.runner.RunWith;

@RunWith(Cucumber.class)
@CucumberOptions(
        features={"src/test/resources/specs/"},
        glue = {"src.test.java.steps"}
)
public class CucuRunnerTest {

}