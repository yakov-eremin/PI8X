// kursPatternsSpec.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "rivWatchers.h"
#include "countFact.h"
#include "sinFacade.h"
#include "gtest/gtest.h"
#include "conio.h"


class LabTest : public ::testing::Test {
protected:
	virtual void SetUp()
	{}
	virtual void TearDown()
	{}
	Facade *wet;
	metCounter *met;
	iceCounter *ice;
	snowCounter *snow;
	weatherCounter *wea;
};

TEST_F(LabTest, Test1) {
	wet = new Facade();
	wet->facadeW(3, 4, 5);
	wet->Consumption();
	EXPECT_EQ(wet->rivParams->watchi->cont, 60);
}

TEST_F(LabTest, Test2) {
	wet = new Facade();
	wet->facadeW(2, 5, 12);
	wet->pConsumption();
	EXPECT_EQ(wet->rivParams->pwatchi->ras->cont, 90);
}

TEST_F(LabTest, Test3) {
	wet = new Facade();
	wet->pConsumption();
	EXPECT_NO_THROW(wet->pConsumption());
}

TEST_F(LabTest, Test4) {
	met = new metCounter();
	met->init(720, 90);
	met->fieldWay->setParams(1, 1, 1);
	ASSERT_NEAR(719.9, met->fieldWay->atFieldCount(720, 90), 0.001);
}

TEST_F(LabTest, Test5) {
	met = new metCounter();
	met->initM("Bobrovka", "Ice", 1);
	ASSERT_EQ(met->getType(), "Snow");
	ASSERT_EQ(met->getName(), "Bobrovka");
}

TEST_F(LabTest, Test6) {
	wea = new weatherCounter();
	wea->init(720, 90);
	wea->meteoCount();
	EXPECT_LE(10000, wea->ets);

}

TEST_F(LabTest, Test7) {
	ice = new iceCounter();
	ice->init(720, 90);
	ice->setWidth(5);
	EXPECT_FALSE(4 > ice->getWidth());
}

TEST_F(LabTest, Test8) {
	ice = new iceCounter();
	ice->init(720, 90);
	ice->icer->setIceParams(12, 24);
	EXPECT_TRUE(5 < ice->icer->setJamEvents(720, 90, 5));
}

TEST_F(LabTest, Test9) {
	snow = new snowCounter();
	snow->init(720, 90);
	snow->setParams(1, 2, 3, 4);
	EXPECT_NO_FATAL_FAILURE(snow->meteoCount());
}

TEST_F(LabTest, Test10) {
	snow = new snowCounter();
	snow->init(720, 90);
	snow->higher->setTime(50);
	EXPECT_DOUBLE_EQ(snow->higher->getTime(), 50);
}

TEST_F(LabTest, Getcher) {
	_getch();
}

int _tmain(int argc, _TCHAR* argv[])
{
	::testing::InitGoogleTest(&argc, argv);
	return RUN_ALL_TESTS();
}

