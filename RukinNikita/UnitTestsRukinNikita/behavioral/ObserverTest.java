package project.patterngenerator.patterns.behavioral;

import javafx.scene.layout.VBox;
import org.junit.jupiter.api.Test;
import project.patterngenerator.patterns.Pattern;
import project.patterngenerator.patterns.creational.FactoryMethod;

import static org.junit.jupiter.api.Assertions.*;

class ObserverTest {

    @Test
    void notifyAllPatterns() {
        Pattern pattern = new Observer(new VBox());
        pattern.notifyAllPatterns();
        assertTrue(pattern.getBox().isVisible());
    }

    @Test
    void get() {
        new Observer(new VBox());
        Pattern pattern = Pattern.get("Observer");
        assertEquals(pattern.getName(), "Observer");
    }

    @Test
    void defineType() {
        new Observer(new VBox());
        assertNotNull(Pattern.creational);
    }
}