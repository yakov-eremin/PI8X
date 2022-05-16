module patterns.pattern {
    requires javafx.graphics;
    requires javafx.controls;
    requires javafx.fxml;

    opens project.patterngenerator to javafx.fxml;
    exports project.patterngenerator;
}