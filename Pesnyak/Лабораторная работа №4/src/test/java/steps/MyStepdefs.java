package steps;

import com.example.bdd.Answer;
import com.example.bdd.Therapist;
import cucumber.api.PendingException;
import cucumber.api.java.en.And;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;
import org.junit.Assert;

public class MyStepdefs {
    Therapist therapist;

    @Given("^I have my virtual computer therapist$")
    public void iHaveMyVirtualComputerTherapist() {
        therapist = new Therapist();
        Assert.assertNotNull(therapist);
    }

    @When("^I entered \"([^\"]*)\" as first symptom$")
    public void iEnteredAsFirstSymptom(String arg0) throws Throwable {
        therapist.tellTherapistAboutSymptom(arg0);
    }

    @And("^I entered \"([^\"]*)\" as second symptom$")
    public void iEnteredAsSecondSymptom(String arg0) throws Throwable {
        // Write code here that turns the phrase above into concrete actions
        therapist.tellTherapistAboutSymptom(arg0);
    }

    @And("^I entered \"([^\"]*)\" as answer$")
    public void iEnteredAsAnswer(String arg0) throws Throwable {
        therapist.answerToTherapist(arg0);
    }

    @And("^Therapist's question should be \"([^\"]*)\"$")
    public void therapistSQuestionShouldBe(String arg0) throws Throwable {
        Assert.assertEquals(arg0, therapist.ask().getAnswer());
    }

    @Then("^Therapist's diagnosis should be \"([^\"]*)\"$")
    public void therapistSDiagnosisShouldBe(String diagnosis) throws Throwable {
        Answer answer = therapist.ask();
        Assert.assertTrue(answer.isDiagnosis());
        Assert.assertEquals(diagnosis, answer.getAnswer());
    }


}
