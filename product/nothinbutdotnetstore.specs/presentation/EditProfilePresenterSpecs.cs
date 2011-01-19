using System;
using nothinbutdotnetstore.presentation;
using nothinbutdotnetstore.presentation.stubs;
using nothinbutdotnetstore.specs.utility;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.presentation
{
    public class EditProfilePresenterSpecs
    {
        public class when_told_to_initialize_and_it_is_not_a_postback : BaseConcern
        {
            OurEditView view;
            EditProfilePresenter sut;
            StubUserStore user_store;
            EditProfileDetail details;

            protected override void arrange()
            {
                view = new OurEditView();
                details = new EditProfileDetail();
                user_store =  new StubUserStore(details);

                sut = new EditProfilePresenter(view,user_store);
            }

            protected override void act()
            {
                sut.initialize();
            }

            [Test]
            public void should_attempt_to_get_the_current_user_from_the_user_store()
            {
                Assert.IsTrue(user_store.received_a_call);
            }

            [Test]
            public void should_tell_the_view_to_display_the_current_user_information()
            {
               Assert.AreEqual(details,view.profile_details);  
            }

        }

        public class when_told_to_initialize_and_it_is__a_postback : BaseConcern
        {
            OurEditView view;
            EditProfilePresenter sut;
            StubUserStore user_store;
            EditProfileDetail details;

            protected override void arrange()
            {
                view = new OurEditView {IsPostBack = true};

                details = new EditProfileDetail();
                user_store =  new StubUserStore(details);
                sut = new EditProfilePresenter(view,user_store);
            }

            protected override void act()
            {
                sut.initialize();
            }

            [Test]
            public void should_not_request_the_user_details()
            {
                Assert.IsFalse(user_store.received_a_call);
            }

            [Test]
            public void should_not_tell_the_view_to_display_details()
            {
                Assert.IsNull(view.profile_details);
            }

        }
    }

    public class OurEditView : EditProfileView
    {
        public EditProfileDetail profile_details { get; set; }
        public bool IsPostBack { get; set; }

        public void display(EditProfileDetail current_user_details)
        {
            profile_details = current_user_details;
        }
    }
}