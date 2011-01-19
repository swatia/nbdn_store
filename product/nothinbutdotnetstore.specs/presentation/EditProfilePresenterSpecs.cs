using System;
using nothinbutdotnetstore.presentation;
using nothinbutdotnetstore.specs.utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.presentation
{
    public class EditProfilePresenterSpecs
    {
        public class when_told_to_initialize_and_it_is_not_a_postback : BaseConcern
        {
            EditProfileView view;
            EditProfilePresenter sut;
            UserStore user_store;
            EditProfileDetail details;

            protected override void arrange()
            {
                view = mock<EditProfileView>();
                details = new EditProfileDetail();
                user_store = mock<UserStore>();
                user_store.Stub(x => x.get_the_current_user_details()).Return(details);

                sut = new EditProfilePresenter(view, user_store, null);
            }

            protected override void act()
            {
                sut.initialize();
            }

            [Test]
            public void should_update_the_view_with_the_detail_information()
            {
                Assert.AreEqual(details.FirstName,view.FirstName);
            }
        }

        public class when_saving_the_user_information : BaseConcern
        {
            EditProfileView view;
            EditProfilePresenter sut;
            UserStore user_store;
            EditProfileDetail details;
            UserManager user_manager;

            protected override void arrange()
            {
                view = mock<EditProfileView>();
                user_store = mock<UserStore>();
                user_manager = mock<UserManager>();

                details = new EditProfileDetail();

                view.FirstName = "this is the first name";

                user_store.Stub(x => x.get_the_current_user_details()).Return(details);

                sut = new EditProfilePresenter(view,user_store,user_manager);
            }

            protected override void act()
            {
                sut.save();
            }

            [Test]
            public void should_update_the_details_of_the_current_user()
            {
                Assert.AreEqual(view.FirstName,details.FirstName);
            }

            [Test]
            public void should_save_the_current_user_details()
            {
               user_manager.AssertWasCalled(x => x.save(details));
            }
        }
    }
}