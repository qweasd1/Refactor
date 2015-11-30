package org.xtext.example.mydsl.tests


import org.junit.runner.*
import org.junit.*
import static org.junit.Assert.*
import org.eclipse.xtext.junit4.*
import org.eclipse.xtext.junit4.util.ParseHelper

import com.google.inject.Inject

import org.xtext.example.mydsl.MyDslInjectorProvider
import org.xtext.example.mydsl.myDsl.*

@RunWith(XtextRunner)
@InjectWith(MyDslInjectorProvider)
class testcase {
	
	@Inject extension ParseHelper<Model>
	
	@Test
	def testNumberConst() {
		assertEquals(('''12'''.parse as NumberConst).value, 12,0) 
	} 
	
	@Test
	def testStringConst() {
		assertEquals(('''"12"'''.parse as StringConst).value, "12") 
	} 
	
	@Test
	def testBoolConst_true() {
		assertEquals(('''true'''.parse as BoolConst).value, true) 
	} 

     @Test
     def testBoolConst_false() {
     	assertEquals(("false".parse as BoolConst).value, false)
     } 
	
	 @Test
     def testAdd_Number_Number() {
     	assertEquals("(1.0+2.0)",("1 + 2".parse as Add).exprLiteral)
     } 
	
	 @Test
	 def testAdd_N_N_N() {
	 	assertEquals("((1.0+2.0)+3.0)", ("1+2+3".parse as Add).exprLiteral)
	 } 
	
	@Test
	def Minus_Number_Number() {
     	assertEquals("(1.0-2.0)",("1 - 2".parse as Minus).exprLiteral)
     } 
     
     @Test
	 def testMius_N_N_N() {
	 	assertEquals("((1.0-2.0)-3.0)", ("1-2-3".parse as Minus).exprLiteral)
	 } 
	 
	 @Test 
	 def testComplex_N_N_N() {
	 	assertEquals("((1.0-2.0)+3.0)", ("1-2+3".parse as Add).exprLiteral)
	 } 
	
	def dispatch String exprLiteral(NumberConst entity){
		entity.value.toString
	}
	
	def dispatch String exprLiteral(BoolConst entity){
		entity.value.toString
	}
	
	def dispatch String exprLiteral(StringConst entity){
		entity.value
	}
	
	def dispatch String exprLiteral(extension Add entity) '''
	(«left.exprLiteral»«op»«right.exprLiteral»)'''
	
	
	def dispatch String exprLiteral(extension Minus entity) '''
	(«left.exprLiteral»«op»«right.exprLiteral»)'''
	
}








