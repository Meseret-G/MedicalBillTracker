
    import React, { useState } from 'react';
    import {
      Collapse,
      Navbar,
      NavbarToggler,
      NavbarBrand,
      Nav,
      NavItem,
      NavLink,
      UncontrolledDropdown,
      DropdownToggle,
      DropdownMenu,
      DropdownItem,
    } from 'reactstrap';
    import logo from '../assets/logo.png'
    
    export default function Navigationbar() {
      const [isOpen, setIsOpen] = useState(false);
    
      const toggle = () => setIsOpen(!isOpen);
    
      return (
        <div className='navbar-container'>
          <Navbar light expand='md' className='navbar'>
            <NavbarBrand href='/'>
              <img className='nav-logo' src={logo} alt='logo' />
            </NavbarBrand>
            <NavbarToggler onClick={toggle} />
            <Collapse isOpen={isOpen} navbar>
              <Nav className='container-fluid' navbar>
                <NavItem>
                  <NavLink href='/'>
                    <span className='nav-span'>Home</span>
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink href='/Cart'>
                    <span className='nav-span'>Review</span>
                  </NavLink>
                </NavItem>
           
                  <>
                    <UncontrolledDropdown nav inNavbar className='user-drop'>
                      <DropdownToggle nav caret>
                        <img
                          className='user-img'
                          //src={user.profilePic}
                          referrerPolicy='no-referrer'
                          alt='user'
                        />
                        <span className='nav-span-user'>user name</span>
                      </DropdownToggle>
                      <DropdownMenu>
                        <DropdownItem>
                          <NavLink>Sign Out</NavLink>
                          <NavLink href='/Patient'>My Account</NavLink>
                        </DropdownItem>
                      </DropdownMenu>
                    </UncontrolledDropdown>
                  </>
                ) : (
                  <>
                    <button
                      type='button'
                      className='login-btn-container'
                    >
                      <img className='login-btn' alt='sign in' />
                    </button>
                  </>
             
              </Nav>
            </Collapse>
          </Navbar>
        </div>
      );
    }
    

